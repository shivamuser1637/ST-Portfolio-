# Shivam Tripathi — Portfolio

A static technical resume website for Shivam Tripathi, built with Vue 3 and Vite. It presents experience, technical proficiencies, selected outcomes, education, and professional development in a dark engineering dashboard style.

## Run locally

Requirements: Node.js 20+.

1. In the project root, run `npm install` and `npm run dev`.
2. Open the local URL printed by Vite (usually `http://localhost:5173`).

## Before publishing

- Replace the sample `mailto:` address in `src/App.vue` with the preferred public email.
- Review the resume content in `src/App.vue` for accuracy before publishing.
- Update the page title and description in `index.html` if desired.
- Deploy the Vite frontend and ASP.NET API, then restrict the API CORS origins to the deployed site.

The website is informational and does not submit contact forms or require a running API. Email and telephone are standard `mailto:` and `tel:` links. The 3D data sculpture is CSS-built, so it does not need a WebGL library. The original ASP.NET Core scaffold remains in `backend/Portfolio.Api`, but the static resume website does not use it.
