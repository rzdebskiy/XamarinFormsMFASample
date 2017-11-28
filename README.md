# MFATestADAL
Super Simple Example of Multi-Factor Authentication in Xamarin Forms iOS/Android/UWP app usign Active Directory Authentication Libabry (ADAL).
Sample is based on [Dependency Service ADAL Sample in Xamarin Blog](https://blog.xamarin.com/put-adal-xamarin-forms/), Windows Phone Silverlight implementation changed to UWP. 

To run the sample 
1. change Client ID to valid Azure Active Directory Application ID in [MainPage.xaml.cs](MFATest/MFATest/MainPage.xaml.cs#L13):

public static string clientId = "INSERT YOUR CLIENT ID HERE";

2. change returnUri in [MainPage.xaml.cs](MFATest/MFATest/MainPage.xaml.cs#L15) to valid URI you have configured in Azure Active Directory App Registration or use existing one from Sample (ensure you configure the same in Azure AD the portal).

Screenshots on how it works:

# iOS:

<p align="center">
<img src="img/iOS_MFA_1.jpg" width="150"/>
<img src="img/iOS_MFA_2.jpg" width="150"/>
<img src="img/iOS_MFA_3.jpg" width="150"/>
<img src="img/iOS_MFA_4.jpg" width="150"/>
<img src="img/iOS_MFA_5.jpg" width="150"/>
</p>

# Android:

<p align="center">
<img src="img/Android_MFA_1.png" width="150"/>
<img src="img/Android_MFA_2.png" width="150"/>
<img src="img/Android_MFA_3.png" width="150"/>
<img src="img/Android_MFA_4.png" width="150"/>
<img src="img/Android_MFA_5.png" width="150"/>
</p>

To make this sample work you need to configure Azure Active Directory:
1. Create Azure Active Directory [tenant and test user with enabled multi-factor authentication](https://docs.microsoft.com/en-us/rest/api/datacatalog/create-an-azure-active-directory-tenant).
2. [Register your application](https://docs.microsoft.com/en-us/rest/api/datacatalog/register-a-client-app) in Azure Active Directroy to get Client ID.
3. Insert Client ID in [MainPage.xaml.cs](MFATest/MFATest/MainPage.xaml.cs#L13)
