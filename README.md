# Portable AMBE Server configuration UI

this program is purposed for configuring "Portable AMBE Server" designed and built by XRF reflector club in Japan.

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
