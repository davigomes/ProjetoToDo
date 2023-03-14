FROM node as build-step
RUN mkdir -p /app
WORKDIR /app
COPY package.json /app
RUN npm install
COPY . /app
RUN npm run build --prod

# Runtime
FROM nginx as runtime-step
COPY --from=build-step /app/dist/todo-frontend /usr/share/nginx/html
COPY ./nginx-custom.conf /etc/nginx/conf.d/default.conf