# C# .NET - Exif Photo Reader

[![NPM](https://img.shields.io/npm/l/react)](https://github.com/andersonpereiradossantos/asp-net-mvc-example-generation-excel-spreadsheets-with-epplus/blob/main/LICENSE) ![nuget](https://img.shields.io/nuget/v/ExifPhotoReader)
![Donwloads](https://img.shields.io/nuget/dt/ExifPhotoReader)

![Logo EXIF Photo Reader](https://raw.githubusercontent.com/andersonpereiradossantos/dotnet-exif-photo-reader/main/Assets/exif-photo-reader-logo.png)

## About code

Library for reading EXIF data from files in JPG and TIFF formats. Written in .NET Standard 2. This library makes use of `System.Drawing.Common` already included in the package.


## Install

On Nuget:
```powershell
PM> Install-Package ExifPhotoReader
```

.NET CLI
```powershell
> dotnet add package ExifPhotoReader
```

## NuGet
https://www.nuget.org/packages/ExifPhotoReader


## Using

Import in your class

``` c#
using ExifPhotoReader;
```
Get EXIF data from an image via a path:
``` c#
ExifImageProperties exifImage = ExifPhoto.GetExifDataPhoto("c:\\fakepath.jpg");
```
Get EXIF data from an image through a Bitmap object:
``` c#
Image file = new Bitmap("C:\\fakepath.jpg");
            
ExifImageProperties exifImage = ExifPhoto.GetExifDataPhoto(file);
```
Get specific EXIF tag of an image:
``` c#
exifImage.Orientation;
//Output: Horizontal
```

## Examples of usage
[.NET Core MVC](https://github.com/andersonpereiradossantos/dotcore-photo-info)


## License
Exif Photo Reader is shared under the MIT license. This means you can modify and use it however you want, even for comercial use. If you liked it, consider marking a ⭐️.

## Author

Anderson Pereira dos Santos

[Linkedin](https://www.linkedin.com/in/andersonpereirasantos)

[Github](https://github.com/andersonpereiradossantos)

