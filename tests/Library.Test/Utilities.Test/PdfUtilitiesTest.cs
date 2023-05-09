using Library.Extensions;
using Library.Test.Helpers;
using Library.Utilities;

namespace Library.Test.Utilities.Test;

public abstract class PdfUtilitiesTest
{
    public class GeneratePdfTest
    {
        [Fact]
        [Trait("PDF", "GeneratePdf")]
        public void Should_Return_PDF_File()
        {
            PdfUtilities utils = new();
            const string html = @"<!DOCTYPE html>
                            <html lang=""en"">
                            <head>
                                <meta charset=""UTF-8"" />
                                <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
                                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                                <title>Hello World!</title>
                            </head>
                            <body>
                                <h1>Hello World!</h1>
                            </body>
                            </html>";

            string file = $@"{Directory.GetCurrentDirectory()}\pdfs\{Guid.NewGuid()}.pdf"
                .Replace("\\bin\\Debug\\net6.0", string.Empty);

            try
            {
                var password = Utils.RandomString(10);

                using var stream = html.ToStream();
                var pdfBytes = utils.ConvertPdFtoByteArray(stream);
                var base64String = utils.EncryptPdFwithPassword(pdfBytes, password, password);
                var bytes = Convert.FromBase64String(base64String);
                File.WriteAllBytes(file, bytes);

                (pdfBytes.Length > 0).Should().BeTrue();
                (base64String.Length > 0).Should().BeTrue();
                (bytes.Length > 0).Should().BeTrue();
            }
            catch (Exception ex)
            {
                throw;
                file = string.Empty;
            }

            file.Should().NotBeNullOrEmpty();
            File.Exists(file).Should().BeTrue();

            if (File.Exists(file))
                File.Delete(file);
        }
    }
}