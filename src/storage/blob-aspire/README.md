# Aspire Blob Storage Example

This sample demonstrates using .NET Aspire with the Azure.Storage.Blobs SDK to upload and download blobs.

## Configuration

Create `BlobAspire.WebApi/appsettings.Development.json` with your storage connection string:

```json
{
  "ConnectionStrings": {
    "BlobStorage": "<your-connection-string>"
  }
}
```

## Running the sample

From this folder run:

```bash
 dotnet run --project BlobAspire.AppHost
```

Then navigate to `http://localhost:5000/swagger` to test the upload and download APIs.
