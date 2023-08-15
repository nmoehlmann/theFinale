FROM node:18 AS Production

ENV NODE_ENV=Production

WORKDIR /app/client

COPY package.json .
COPY package-lock.json .

RUN npm install

COPY . .

RUN npm run build

CMD ["npm", "run", "start"]