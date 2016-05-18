# Xamarin Applications for Kaazing WebSocket JMS API

This repository contains Xamarin Sample Applications for Android, iOS Classic, iOS Unified that use Kaazing WebSocket JMS API

## Building instructions
__Note__: Some times Xamarin cannot properly restore the references from the packages configured vid NuGet; as the result solution build fails.

To resolve this issue:
- Open KaazingJMSXamarinDemo.Android
  - Open 'Packages'
  - Remove _all_ packages
  - Using NuGet add package "Xamarin.Forms"
- Open KaazingJMSXamarinDemo.Common
  - Open 'Packages'
  - Remove _all_ packages
  - Using NuGet add package "Xamarin.Forms"
  - Using NuGet add package "Kaazing.Enterprize"
- Open KaazingJMSXamarinDemo.iOS.Classic
  - Open 'Packages'
  - Remove _all_ packages
  - Using NuGet add package "Xamarin.Forms"
