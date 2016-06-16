# Kaazing Xamarin WebSocket JMS Tutorial

This tutorial shows how Xamarin application can communicate over the web with a JMS server via Kaazing WebSocket Gateway using Kaazing Xamarin WebSocket Client library. The application publishes text messages to the server and listens to the messages from the server over WebSocket.

## Minimum Requirements for Running or Building Kaazing Xamarin WebSocket JMS Tutorial

* SDK Level 21 
to install - In Xamarin studio use: Tools -> Open Android SDK Manager
* Create provisioning profile for Xamarin 
[Set up your device for development](https://developer.xamarin.com/guides/ios/getting_started/installation/device_provisioning/) 
and/or 
[Detailed Instructions] (https://developer.xamarin.com/guides/ios/getting_started/installation/device_provisioning/free-provisioning/)

## Steps for building the project

* Load the solution `jms.client.xamarin.demo.sln` in Xamarin Studio
* Execute 'Build/Build All'

__Note:__ To test basic authentication for WebSocket connection in demo app use URL -  wss://sandbox.kaazing.net/jms-auth for location.

## Interact with Kaazing Xamarin WebSocket JMS Client API

Checklist how to create Kaazing Xamarin WebSocket JMS application from scratch, to be able to send and receive messages over WebSocket, can be found [here](http://kaazing.com/doc/5.0/jms_client_docs/dev-dotnet/xamarin_dotnet_walkthrough.html).

## API Documentation

API Documentation for Kaazing .NET/Xamarin WebSocket JMS Client library is available:

* [Kaazing.JMS](https://kaazing.com/doc/jms/4.0/apidoc/client/dotnet/jms/html/N_Kaazing_JMS.htm)
* [Kaazing.JMS.Stomp](https://kaazing.com/doc/jms/4.0/apidoc/client/dotnet/jms/html/N_Kaazing_JMS_Stomp.htm)
* [Kaazing.JMS.Util](https://kaazing.com/doc/jms/4.0/apidoc/client/dotnet/jms/html/N_Kaazing_JMS_Util.htm)
* [Kaazing.Security](https://kaazing.com/doc/legacy/4.0/apidoc/client/dotnet/gateway/html/N_Kaazing_Security.htm)
