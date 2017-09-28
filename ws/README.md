# Kaazing Xamarin WebSocket Tutorial

This Xamarin application communicates with an `Echo` service hosted by Kaazing WebSocket Gateway. The application sends and receives  messages with the `Echo` service.

## Minimum Requirements for Running or Building

* SDK Level 21 - To install, in Xamarin Studio use 'Tools -> Open Android SDK Manager'
* Create a provisioning profile for Xamarin by following [Set up your device for development](https://developer.xamarin.com/guides/ios/getting_started/installation/device_provisioning/) and/or [Detailed Instructions] (https://developer.xamarin.com/guides/ios/getting_started/installation/device_provisioning/free-provisioning/) from Apple.

## Steps for Building the Project

* Load the solution `ws.client.xamarin.demo.sln` in Xamarin Studio
* Execute 'Build/Build All'

__Note:__ To test basic authentication for the Gateway connection use the URL `wss://demos.kaazing.com/echo-auth` for location.
</br>
username: tutorial </br>
password: tutorial 

## API Documentation

API Documentation for Kaazing .NET/Xamarin WebSocket Client library is available:

* [Kaazing.HTML5](https://kaazing.com/doc/legacy/4.0/apidoc/client/dotnet/gateway/html/N_Kaazing_HTML5.htm)
* [Kaazing.Security](https://kaazing.com/doc/legacy/4.0/apidoc/client/dotnet/gateway/html/N_Kaazing_Security.htm)
