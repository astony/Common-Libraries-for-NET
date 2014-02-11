﻿//TODO: add license header

using System;
using Salesforce.Common.Models;

namespace Salesforce.Common
{
    public static class Common
    {
        public static string FormatUrl(string resourceName, string instanceUrl, string apiVersion)
        {
            if (string.IsNullOrEmpty(resourceName)) throw new ArgumentNullException("resourceName");
            if (string.IsNullOrEmpty(instanceUrl)) throw new ArgumentNullException("instanceUrl");
            if (string.IsNullOrEmpty(apiVersion)) throw new ArgumentNullException("apiVersion");
            
            return string.Format("{0}/services/data/{1}/{2}", instanceUrl, apiVersion, resourceName);
        }

        public static string FormatAuthUrl(
            string loginUrl,
            ResponseTypes responseType,
            string clientId,
            string redirectUrl,
            DisplayTypes display = DisplayTypes.Page,
            bool immediate = false,
            string state = "",
            string scope = "")
        {
            if (string.IsNullOrEmpty(loginUrl)) throw new ArgumentNullException("loginUrl");
            if (string.IsNullOrEmpty(clientId)) throw new ArgumentNullException("clientId");
            if (string.IsNullOrEmpty(redirectUrl)) throw new ArgumentNullException("redirectUrl");
            //TODO: check ensure that redirectUrl is a valid URI

            var url =
            string.Format(
                "{0}?response_type={1}&client_id={2}&redirect_uri={3}&display={4}&immediate={5}&state={6}&scope={7}",
                loginUrl,
                responseType.ToString().ToLower(),
                clientId,
                redirectUrl,
                display.ToString().ToLower(),
                immediate,
                state,
                scope);

            return url;
        }
    }
}
