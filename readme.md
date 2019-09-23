# CoreIAdHocExtensionSamples

## Overview

This repository was created to streamline the implementation of our IAdHocExtension methods. In a standalone instance of Izenda, or in a
DeploymentMode 1 instance (The API/back-end is separate from the front-end solution) it is necessary to construct a .dll to employ these behaviors.
The provided solution will generate a .dll for you once it is built that you can place alongside the other .dlls in our API.

 :warning: **This is designed for demonstration purposes and should not be used "as-is" in a production environment. You can use this for reference or a baseline but ensure that security and customization meet the standards of your company.**

## Getting Started 

Note: **You will need .net core 2.2.0 or higher to use this solution**

After downloading the contents of the repository, you will see one file, CustomAdhocReports.cs, within the solution once you've opened it. This file will be where
you can build out any overrides for our IAdHocExtention methods that you would like to utilize in your environment. 

The only .dll you need for this solution to work is the Izenda.BI.Framework.dll, which is already provided for you in the solution. This was constructed
using the v2.18.1 resources.

## Use and Repurposing

In order to use this sample, all you will need to do is create the logic you want to test or employ within the CustomAdhocReports.cs file. Once complete,
all you need to do is build the solution. Within the /bin/ directory should be a .dll file named CustomAdhocReports.dll. Take this file and place it alongside
the Izenda API's other .dll resources. Once you restart the site, these extension methods will be employed within your environment.

## Reference

For more information on the methods you can employ within this solution or for further information 
on the syntax for this file please see our wiki: https://www.izenda.com/docs/dev/ref_iadhocextension.html 
 