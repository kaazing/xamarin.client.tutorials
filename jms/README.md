# Xamarin Applications for Kaazing WebSocket JMS API

This repository contains the Xamarin Sample Applications for Android, iOS Classic, iOS Unified that use the Kaazing WebSocket JMS API.

## Building instructions
__Note__: Sometimes Xamarin cannot properly restore the references from the packages configured via NuGet. As a result, the build solution fails.

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
