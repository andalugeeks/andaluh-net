# Andaluh.NET

Transliterate español (spanish) spelling to andaluz proposals.

For information about the inspiration for this project, please visit https://github.com/andalugeeks/andaluh-py
Have fun!

## Table of Contents

- [Description](#description)
- [Usage](#usage)
- [Installation](#installation)
- [Support](#support)
- [Contributing](#contributing)

## Description

The **Andalusian varieties of [Spanish]** (Spanish: *andaluz*; Andalusian) are spoken in Andalusia, Ceuta, Melilla, and Gibraltar. They include perhaps the most distinct of the southern variants of peninsular Spanish, differing in many respects from northern varieties, and also from Standard Spanish. Further info: https://en.wikipedia.org/wiki/Andalusian_Spanish.

This package introduces transliteration functions to convert *español* (spanish) spelling to andaluz. As there's no official or standard andaluz spelling, andaluh-py is adopting the **EPA proposal (Er Prinzipito Andaluh)**. Further info: https://andaluhepa.wordpress.com. Other andaluz spelling proposals are planned to be added as well.

## Usage

Go to `TestApp` folder type `dotnet run "Hola mundo"` to perform your own tests with your text. You don't have to type only one word but don't forget the quotation marks!

```shell
andaluh-net$ ls
Andaluh  Andaluh.sln  README.md  TestApp  Tests
andaluh-net$ cd TestApp/
andaluh-net/TestApp$ dotnet run "El veloz murciélago hindú comía feliz cardillo y kiwi. La cigüeña tocaba el saxofón detrás del palenque de paja"
Transcripción => Er belôh murçiélago indú comía felîh cardiyo y kiwi. La çigueña tocaba er çâççofón detrâh der palenque de paha
```

## Installation

- Install the latest version of the .NET Core SDK https://dotnet.microsoft.com/download/dotnet-core/3.1
- Open a console and go to the root folder of the project. I will call it.
- There you can type `dotnet test` to see how the library performs (This is a bit slow as it tests 87000 cases).

## Support

Please [open an issue](https://github.com/andalugeeks/andaluh-net/issues/new) for support.

## Contributing

Please contribute using [Github Flow](https://guides.github.com/introduction/flow/). Create a branch, add commits, and open a pull request.