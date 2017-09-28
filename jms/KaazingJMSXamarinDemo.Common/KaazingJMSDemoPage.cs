﻿/**
 * Copyright (c) 2007-2013, Kaazing Corporation. All rights reserved.
 */
using System;
using Xamarin.Forms;
using System.Windows.Input;
using Kaazing.JMS;
using Kaazing.JMS.Stomp;
using System.Collections.Generic;
using Kaazing.Security;
using System.Threading.Tasks;
using Kaazing.HTML5;
using System.Threading;

namespace KaazingJMSXamarinDemo
{
    public class KaazingJMSDemoPage : ContentPage
    {
        Entry uriEntry;
        Entry destinationEntry;
        Entry messageEntry;

        Button connectButton;
        Button subscribeButton;
        Button sendButton;
        Button clearButton;

        Label logLabel;


        KaazingJMSDemoController _controller;

        public KaazingJMSDemoPage()
        {
            _controller = new KaazingJMSDemoController(this);

            Title = "KaazingJMSXamarinDemo";
            BackgroundColor = Color.FromRgb(255, 140, 0);

            uriEntry = new Entry {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "wss://demos.kaazing.com/jms",
            };

            uriEntry.Focus();

            destinationEntry = new Entry {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "/topic/destination"
            };

            messageEntry = new Entry {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Hello Kaazing!"
            };

            connectButton = new Button {
                Text = "Connect",
                BindingContext = this,
            };
            connectButton.Clicked += _controller.ConnectOrDisconnect;

            subscribeButton = new Button {
                Text = "Subscribe",
                BindingContext = this,
            };
            subscribeButton.Clicked += _controller.Subscribe;

            sendButton = new Button {
                Text = "Send",
                BindingContext = this,
            };
            sendButton.Clicked += _controller.SendMessage;

            clearButton = new Button {
                Text = "Clear",
                BindingContext = this,
            };
            clearButton.Clicked += _controller.ClearLog;

            logLabel = new Label {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.End,
                TextColor = Color.Black
            };

            // Create a grid to hold the Labels & Entry controls.
            Grid inputGrid = new Grid {
                ColumnDefinitions = {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },                    
                    new ColumnDefinition { Width = GridLength.Auto },                 
                },
                Children = { {
                        new Label {
                            Text = "URI:", 
                            HorizontalTextAlignment = TextAlignment.End,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = Fonts.SmallTitle.FontSize,
                            FontAttributes = Fonts.SmallTitle.FontAttributes,
                            FontFamily = Fonts.SmallTitle.FontFamily,
                            TextColor = Colours.SubTitle
                        },0,0
                    }, {
                        new Label {
                            Text = "Destination:",
                            HorizontalTextAlignment = TextAlignment.End,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = Fonts.SmallTitle.FontSize,
                            FontAttributes = Fonts.SmallTitle.FontAttributes,
                            FontFamily = Fonts.SmallTitle.FontFamily,
                            TextColor = Colours.SubTitle
                        }, 0,1
                    }, {
                        new Label {
                            Text = "Message: ",
                            HorizontalTextAlignment = TextAlignment.End,
                            VerticalTextAlignment = TextAlignment.Center,
                            FontSize = Fonts.SmallTitle.FontSize,
                            FontAttributes = Fonts.SmallTitle.FontAttributes,
                            FontFamily = Fonts.SmallTitle.FontFamily,
                            TextColor = Colours.SubTitle
                        },0, 2
                    },
                    { uriEntry, 1, 0 },
                    { destinationEntry, 1, 1 },
                    { messageEntry, 1, 2 },
                    { connectButton, 2, 0}, 
                    { subscribeButton, 2, 1},
                    { sendButton, 2, 2}
                }
            };

            inputGrid.Padding = new Thickness(10);

            var logView = new ScrollView {
                Content = new StackLayout {
                    Padding = new Thickness(5),
                    BackgroundColor = Color.White,
                    Children = { logLabel } 
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = ScrollOrientation.Vertical, 
                BackgroundColor = Color.White
            };

            var relativeLayout = new RelativeLayout {
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 40
            };

            relativeLayout.Children.Add(clearButton,
                Constraint.RelativeToParent((parent) => {
                    return parent.Width - 60;
                }),
                Constraint.RelativeToParent((parent) => {
                    return 0;
                }));

            Content = new StackLayout {
                Children = {
                    inputGrid,
                    logView,
                    relativeLayout
                }
            };

            EnableUI(false);
        }

        public string URI {
            get { return uriEntry.Text;}
        }

        public string Destination {
            get { return destinationEntry.Text;}
        }

        public string Message {
            get { return messageEntry.Text;}
        }

        public string LogView {
            get { return logLabel.Text;}
            set { logLabel.Text = value; }
        }

        public void Log(string message)
        {
            Device.BeginInvokeOnMainThread(() => {
                logLabel.Text = logLabel.Text + "\n" + message;
            });
        }

        public void wainForConnect(bool wait){
            Device.BeginInvokeOnMainThread (() => {
                if (wait) {
                    connectButton.IsEnabled=false;
                } else {
                    connectButton.IsEnabled=true;
                }
            });
        }

        public void readyToSend(){
            Device.BeginInvokeOnMainThread (() => {
                sendButton.IsEnabled = true;
            });
        }

        public void EnableUI(bool enable)
        {
            Device.BeginInvokeOnMainThread(() => {
                if (enable) {
                    connectButton.Text = "Disconnect";
                    subscribeButton.IsEnabled = true;
                } else {
                    connectButton.Text = "Connect";
                    subscribeButton.IsEnabled = false;
                    sendButton.IsEnabled = false;
                }
            });
        }
    }
}

