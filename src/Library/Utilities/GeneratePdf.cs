namespace Library.Utilities;

public static class GeneratePdf
{
    public static Stream GenerateStreamFromString(string? str)
    {
        /*var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(str);
        writer.Flush();
        stream.Position = 0;
        return stream;*/
        return new MemoryStream(Encoding.UTF8.GetBytes(str ?? ""));
    }

    /// <summary> Generate PDF file with password from HTML String </summary>
    /// <param name="html">HTML string with content of convert in pdf file</param>
    /// <param name="path">Path where save pdf file</param>
    /// <param name="userPassword">Password to encrypt PDF file</param>
    /// <returns>Path with encrypted pdf file created</returns>
    public static string WithPassword(string? html, string? path, string? userPassword)
    {
        if (html is null || path is null || userPassword is null)
            return string.Empty;

        try
        {
            string file = $@"{path}\{Guid.NewGuid()}.pdf";
            PdfUtilities utils = new();

            using Stream stream = GenerateStreamFromString(html);
            var pdfBytes = utils.ConvertPdFtoByteArray(stream);
            var base64String = utils.EncryptPdFwithPassword(pdfBytes, userPassword, userPassword);
            var bytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(file, bytes);
            return file;
        }
        catch
        {
            return string.Empty;
        }
    }

    /// <summary> Generate PDF file from HTML String </summary>
    /// <param name="html">HTML string with content of convert in pdf file</param>
    /// <param name="path">Path where save pdf file</param>
    /// <returns>Path with pdf file created</returns>
    public static string GeneratePdfFromString(string? html, string path)
    {
        try
        {
            string file = $@"{path}\{Guid.NewGuid()}.pdf";
            PdfUtilities utils = new();

            using Stream htmlSource = GenerateStreamFromString(html);
            var pdfBytes = utils.ConvertPdFtoByteArray(htmlSource);
            var base64String = utils.ConvertPdFtoBase64String(pdfBytes);
            var bytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(file, bytes);
            return file;
        }
        catch
        {
            return string.Empty;
        }
    }
}