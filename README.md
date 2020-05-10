# AspNetCore How-To Samples
Code samples for ASP.NET Core

## Upload file
Upload file with a model maybe tricky for beginners. In this [line](https://github.com/Redouane64/AspNetCore.Samples/blob/d49dcd31d38c320bd6dccbb7132883ffd7586449/UploadFile/Controllers/HomeController.cs#L45) you handle the POST request and do not forgot to set form `enctype="multipart/form-data"` as set in the corresponding handler [view](https://github.com/Redouane64/AspNetCore.Samples/blob/d49dcd31d38c320bd6dccbb7132883ffd7586449/UploadFile/Views/Home/UploadFile.cshtml#L9).
