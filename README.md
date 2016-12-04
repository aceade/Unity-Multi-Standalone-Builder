# Unity-Multi-Standalone-Builder
A Unity Editor script that allows you to build standalone builds for multiple platforms with one click.

Creating standalone builds for Linux, Mac and Windows requires manually changing the build platform after each build. This is tedious, so I created this Editor script to automate the process. 
I created this with Unity 5.3.6f1. The API may be different in 5.4 or 5.5.

## How to use it
Download or clone the repo, and copy it into the Assets/Aceade folder.
Click on the Tools menu, then click on "Aceade", then "Multi-Standalone Build". By default, it creates a 64-bit Linux, 64-bit Windows and 64-bit Mac build in a folder named "Player Files" directly below the project root.

### Changing the defaults
The default naming convention is "{Application.name}\_{Platform}\_{BuildDate}", e.g. "BuildProcess_Linux_4.12.2016". To change the build date, you will need to edit the `GetBuildDate` method.

## Licence

MIT Licence
