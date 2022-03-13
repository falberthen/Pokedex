import { createApp, provide, h } from 'vue'
import { DefaultApolloClient } from '@vue/apollo-composable'
import { ApolloClient, HttpLink, InMemoryCache, split } from '@apollo/client/core'
import { WebSocketLink } from "@apollo/client/link/ws"
import { getMainDefinition } from '@apollo/client/utilities'
import App from './App.vue'
interface Definintion {
  kind: string
  operation?: string
}

const httpLink = new HttpLink({
  // You should use an absolute URL here
  uri: 'https://localhost:7221/graphql/',
})

// Create the subscription websocket link
const wsLink = new WebSocketLink({
  uri: "wss://localhost:7221/graphql/",
  options: {
    reconnect: true,
  },
})

// using the ability to split links, you can send data to each link
// depending on what kind of operation is being sent
const link = split(
  // split based on operation type
  ({ query }) => {
    const { kind, operation }: Definintion = getMainDefinition(query)
    return kind === "OperationDefinition" && operation === "subscription"
  },
  wsLink,
  httpLink
)

// Create the apollo client
const apolloClient = new ApolloClient({
  link,
  cache: new InMemoryCache(),
  connectToDevTools: true,
})

const app = createApp({
  setup () {
    provide(DefaultApolloClient, apolloClient)
  },

  render: () => h(App),
})

app.mount('#app');