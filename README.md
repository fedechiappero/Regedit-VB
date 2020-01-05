# Regedit-VB
Read and write registry keys with your app

## Why?
Because you may have a really simple app that need some sort of anti-piracy security, or your app is the same for every installation but you want to restrict access to some features.

### How it works
The app reads the serial number hdd and use it as "serial". You can get it by running on ```cmd```:
> wmic diskdrive get serialnumber

So you input this code on the app and you get access granted to use it, but you need to enable some features to use. In order to do that, you can input values on txt_values control and save them to the registry.

Obviously, this is a dummy app, it only contains a basic structure to achive what i wanted to do, you'll need to add more code.
