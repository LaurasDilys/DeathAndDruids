import * as actionTypes from "../actions/actionTypes";
import { Monster } from './creationReducer';

export type MonstersState = {
  monsters: Monster[]
}

const initialState: MonstersState = {
  monsters: []
}

type MonstersAction = {
  type: string;
  payload: Monster[];
}

const monstersReducer = (state: MonstersState = initialState, action: MonstersAction): MonstersState => {
  switch (action.type) {
    case (actionTypes.GET_MONSTERS):
      return { ...state, monsters: action.payload };
    default:
      return state;
  };
};

export default monstersReducer;