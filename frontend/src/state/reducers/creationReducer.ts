import * as actionTypes from "../actions/actionTypes";

export type Monster = {
  id: number,
  name: string,
  initiative: number,
  sourceId: number,
  saved: boolean
}

export type CreationState = {
  monster: Monster
}

const initialState = null as unknown as CreationState;

type CreationAction = {
  type: string;
  payload: Monster;
}

const creationReducer = (state: CreationState = initialState, action: CreationAction): CreationState => {
  switch (action.type) {
    case (actionTypes.GET_OPENED_MONSTER):
      return { ...state, monster: action.payload };
    default:
      return state;
  };
};

export default creationReducer;