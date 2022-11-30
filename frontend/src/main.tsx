import React from "react";
import ReactDOM from "react-dom/client";
import { MsalProvider } from "@azure/msal-react";

import { config } from "@api/mssso.config";

import App from "./app";

import "@styles/global/main.css";

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <MsalProvider instance={config}>
      <App />
    </MsalProvider>
  </React.StrictMode>
);
