import { useEffect } from "react";
import { useCookies } from "react-cookie";
import { useMsalAuthentication } from "@azure/msal-react";

import {
  InteractionType,
  InteractionRequiredAuthError,
} from "@azure/msal-browser";

import { api } from "@api/mssso.config";
import { baseUrl } from "@api/app.config";

export default () => {
  const [_, setCookie] = useCookies(["t"]);

  const { login, result, error } = useMsalAuthentication(
    InteractionType.Silent,
    {
      scopes: [...api.scopes],
    }
  );

  useEffect(() => {
    if (error instanceof InteractionRequiredAuthError) {
      login(InteractionType.Redirect, { scopes: [...api.scopes] });
    }
  }, [error]);

  useEffect(() => {
    if (error || !result?.accessToken) {
      return;
    }

    setCookie("t", result.accessToken);
    window.location.replace(baseUrl);
  }, [result, error]);

  return null;
};
