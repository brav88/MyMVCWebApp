﻿using Firebase.Auth.Providers;
using Firebase.Auth;

namespace MyWebApp.Firebase
{
    public static class FirebaseAuthHelper
    {
        public const string firebaseAppId = "";
        public const string firebaseApiKey = "";

        public static FirebaseAuthClient setFirebaseAuthClient()
        {
            var auth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = firebaseApiKey,
                AuthDomain = firebaseAppId,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });

            return auth;
        }
    }
}
