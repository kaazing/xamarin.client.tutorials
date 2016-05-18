# Xamarin Applications for Kaazing WebSocket API

This repository contains Xamarin Sample Applications for Android, iOS Classic, iOS Unified that use Kaazing WebSocket API

## Building instructions
__Note__: Some times Xamarin cannot properly restore the references from the packages configured vid NuGet; as the result solution build fails.

To resolve this issue:
- Open KaazingWsXamarinDemo.Android
  - Open 'Packages'
  - Remove _all_ packages
  - Using NuGet add package "Xamarin.Forms"
- Open KaazingWsXamarinDemo.Common
  - Open 'Packages'
  - Remove _all_ packages
  - Using NuGet add package "Xamarin.Forms"
  - Using NuGet add package "Kaazing.Enterprize"
- Open KaazingWsXamarinDemo.iOS.Classic
  - Open 'Packages'
  - Remove _all_ packages
  - Using NuGet add package "Xamarin.Forms"
  
