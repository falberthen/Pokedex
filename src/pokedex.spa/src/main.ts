import { createApp, provide, h } from 'vue'
import { DefaultApolloClient } from '@vue/apollo-composable'
import { ApolloClient, InMemoryCache } from '@apollo/client/core'
import App from './App.vue'

// Set up subscription
// const wsLink = new WebSocketLink({
//   uri: `wss://localhost:7221/graphql`,
//   options: {
//     reconnect: true
//   }
// });

const apolloClient = new ApolloClient({
  cache: new InMemoryCache(),
  uri: 'https://localhost:7221/graphql/',
})

const app = createApp({
  setup () {
    provide(DefaultApolloClient, apolloClient)
  },

  render: () => h(App),
})

app.mount('#app');