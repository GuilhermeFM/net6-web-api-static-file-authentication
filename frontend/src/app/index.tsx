import { CookiesProvider } from "react-cookie";

import Home from "@pages/Home";

export default () => {
  return (
    <CookiesProvider>
      <Home />
    </CookiesProvider>
  );
};
