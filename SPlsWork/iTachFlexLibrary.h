namespace iTachFlexLibrary;
        // class declarations
         class TCPClientClass;
         class iTachFlexClass;
     class TCPClientClass 
    {
        // class delegates
        delegate FUNCTION ReceiveDataHandler ( SIMPLSHARPSTRING data );

        // class events

        // class functions
        FUNCTION InitializeTcpClient ( STRING addressToConnectTo , LONG_INTEGER portNumber , LONG_INTEGER bufferSize );
        FUNCTION ConnectToServer ();
        FUNCTION DisconnectFromServer ();
        FUNCTION SendData ( SIMPLSHARPSTRING dataToSend );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        LONG_INTEGER debug;

        // class properties
        DelegateProperty ReceiveDataHandler OnDataReceiveEvent;
    };

     class iTachFlexClass 
    {
        // class delegates
        delegate FUNCTION UpdateNetworkSettings ( SIMPLSHARPSTRING configlock , SIMPLSHARPSTRING ipsetting , SIMPLSHARPSTRING ipaddress , SIMPLSHARPSTRING subnet , SIMPLSHARPSTRING gateway );

        // class events

        // class functions
        FUNCTION dataReceive ( STRING data );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty UpdateNetworkSettings UpdateNetworkSettingsEvent;
    };

