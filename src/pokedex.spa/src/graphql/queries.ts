import { gql } from "@apollo/client/core";

export const pokemonByNumber= gql`
  query pokemonByNumber($number: Int!) {
    pokemonByNumber(number: $number){
      number 
      name
      primaryType
      secondaryType
      catchRate
      isLegendary
      evolvesTo {
        number
        name
      }
      evolvesFrom {
        number
        name
      }
      genderRatio {
        femaleRatio
        maleRatio
      }
      physicalAttributes {
        height
        weigth
      }
      baseStats {
        hP
        attack
        defense
        specialAttack
        specialDefense
        speed
      }
      avatar
    }
  }
`