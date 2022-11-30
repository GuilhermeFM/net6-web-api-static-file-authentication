import { PublicClientApplication } from "@azure/msal-browser";

export const config = new PublicClientApplication({
  auth: {
    clientId: "",
    authority: "https://login.microsoftonline.com/common",
    redirectUri: import.meta.env.VITE_REDIRECT_URL,
  },
  cache: {
    cacheLocation: "sessionStorage",
    storeAuthStateInCookie: false,
  },
});

export const api = {
  scopes: [""],
};

config.logoutRedirect({
  onRedirectNavigate: () => {
    return false;
  },
});
