import * as actionTypes from "../actions/actionTypes";

export type LocationState = {
  selectedTab: number;
}

const initialState: LocationState = {
  selectedTab: 0
}

type LocationAction = {
  type: string;
  payload: number;
}

const locationReducer = (state: LocationState = initialState, action: LocationAction): LocationState => {
  switch (action.type) {
    case (actionTypes.GET_SELECTED_TAB):
      return { ...state, selectedTab: action.payload };
    default:
      return state;
  };
};

export default locationReducer;