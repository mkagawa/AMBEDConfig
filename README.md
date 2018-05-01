# Portable AMBE Server configuration UI

This program is purposed for configuring "Portable AMBE Server" designed and built by XRF reflector club in Japan. This porition of the project is written by NW6UP.

## Lisence

MIT License

Copyright (c) 2018 Masahito Kagawa (NW6UP)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

## How it works

The program is to be executed on Windows PC environment (Windows 7 or later), and the end user modifies parameter accoding to his/her environment.
Click OK to save the changes, or is no changes, no files will be modified.
The target files are following 4 files.
  - AMBEDCMD.txt
  - sshd_config.txt
  - AMBEServerGPIO.txt
  - dhcpcd.txt
These files should be symbolic linked to the corresponding configuration files in the Linux system.

## Build

This project is designed and built by Microsoft Visual Studio Express for Desktop (Free version). The project is written in C# language. Utilizes .NET version 3.5 client profile runtime.
