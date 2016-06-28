# Kaazing Xamarin JMS Tutorial

This Xamarin application communicates with a JMS broker via Kaazing WebSocket Gateway. The application publishes and receives messages with the broker.

## Minimum Requirements for Running or Building

* SDK Level 21 - To install, in Xamarin studio use Tools -> Open Android SDK Manager
* Create a provisioning profile for Xamarin by following  
[Set up your device for development](https://developer.xamarin.com/guides/ios/getting_started/installation/device_provisioning/) 
and/or 
[Detailed Instructions] (https://developer.xamarin.com/guides/ios/getting_started/installation/device_provisioning/free-provisioning/) from Apple.

## Steps for Building the Project

* Load the solution `jms.client.xamarin.demo.sln` in Xamarin Studio
* Execute 'Build/Build All'

__Note:__ To test basic authentication for Gateway connection use the URL `wss://sandbox.kaazing.net/jms-auth` for location.

## Interact with Kaazing Xamarin WebSocketJMS Client API

Documentation on how to create a Kaazing Xamarin JMS application from scratch can be found [here](http://kaazing.com/doc/5.0/jms_client_docs/dev-dotnet/xamarin_dotnet_walkthrough.html).

## API Documentation

API Documentation for Kaazing .NET/Xamarin WebSocket JMS Client library is available:

* [Kaazing.JMS](https://kaazing.com/doc/5.0/jms_client_docs/apidoc/client/dotnet/jms/html/N_Kaazing_JMS.htm)
* [Kaazing.JMS.Stomp](https://kaazing.com/doc/5.0/jms_client_docs/apidoc/client/dotnet/jms/html/N_Kaazing_JMS_Stomp.htm)
* [Kaazing.JMS.Util](https://kaazing.com/doc/5.0/jms_client_docs/apidoc/client/dotnet/jms/html/N_Kaazing_JMS_Util.htm)
* [Kaazing.Security](https://kaazing.com/doc/5.0/jms_client_docs/apidoc/client/dotnet/jms/html/N_Kaazing_Security.htm)
