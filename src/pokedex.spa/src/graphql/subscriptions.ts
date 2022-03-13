import { gql } from "@apollo/client/core";

export const onListPokemon= gql`
subscription{
  onListPokemon
}
`;

export const onInsertPokemon= gql`
subscription{
  onInsertPokemon{
    number
    name
  }
}
`;

export const onUpdatePokemon= gql`
subscription{
  onUpdatePokemon{
    number
    name
  }
}
`;