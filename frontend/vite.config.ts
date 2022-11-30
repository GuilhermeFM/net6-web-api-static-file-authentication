import { defineConfig } from "vite";

import react from "@vitejs/plugin-react";

export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: [
      { find: "@assets", replacement: "/src/app/assets" },
      { find: "@components", replacement: "/src/app/components" },
      { find: "@layouts", replacement: "/src/app/layouts" },
      { find: "@pages", replacement: "/src/app/pages" },
      { find: "@api", replacement: "/src/other/api" },
      { find: "@hooks", replacement: "/src/other/hooks" },
      { find: "@providers", replacement: "/src/other/providers" },
      { find: "@styles", replacement: "/src/other/styles" },
    ],
  },
});
