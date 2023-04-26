namespace Library.Utilities;

public class PdfUtilities
{
    public byte[] ConvertPdFtoByteArray(Stream html)
    {
        using MemoryStream memStream = new();
        WriterProperties wp = new();
        using (PdfWriter writer = new(memStream, wp))
        {
            writer.SetCloseStream(true);

            PdfDocument document;
            using (document = new PdfDocument(writer))
            {
                ConverterProperties props = new();

                document.SetDefaultPageSize(PageSize.LETTER);
                document.SetCloseWriter(true);
                document.SetCloseReader(true);
                document.SetFlushUnusedObjects(true);
                HtmlConverter.ConvertToPdf(html, document, props);

                document.Close();
            }
        }

        var buffer = memStream.ToArray();

        return buffer;
    }

    public string EncryptPdFwithPassword(byte[] bytes, string passwordUser, string passwordOwner)
    {
        byte[] userPassword = Encoding.ASCII.GetBytes(passwordUser),
            ownerPassword = Encoding.ASCII.GetBytes(passwordOwner);

        PdfReader reader = new(new MemoryStream(bytes));
        var wp = new WriterProperties()
            .SetStandardEncryption(userPassword, ownerPassword,
                EncryptionConstants.ALLOW_PRINTING,
                EncryptionConstants.ENCRYPTION_AES_128 |
                EncryptionConstants.DO_NOT_ENCRYPT_METADATA);

        using var stream = new MemoryStream();
        PdfWriter writer = new(stream, wp);
        PdfDocument doc = new(reader, writer);
        doc.Close();
        var encryptedBase64 = Convert.ToBase64String(stream.ToArray());

        return encryptedBase64;
    }

    public string ConvertPdFtoBase64String(byte[] bytes)
    {
        PdfReader reader = new(new MemoryStream(bytes));
        WriterProperties wp = new();

        using var stream = new MemoryStream();
        PdfWriter writer = new(stream, wp);
        PdfDocument doc = new(reader, writer);
        doc.Close();
        var encryptedBase64 = Convert.ToBase64String(stream.ToArray());

        return encryptedBase64;
    }
}