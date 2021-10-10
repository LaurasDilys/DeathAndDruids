import * as actionTypes from "../actions/actionTypes";
import { Monster } from './creationReducer';

export type CombatState = {
  combatants: Monster[]
}

const initialState: CombatState = {
  combatants: []
}

type CombatAction = {
  type: string;
  payload: Monster[];
}

const combatReducer = (state: CombatState = initialState, action: CombatAction): CombatState => {
  switch (action.type) {
    case (actionTypes.GET_COMBATANTS):
      return { ...state, combatants: action.payload };
    default:
      return state;
  };
};

export default combatReducer;