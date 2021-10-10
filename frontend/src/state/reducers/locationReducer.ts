import * as actionTypes from "../actions/actionTypes";

export type LocationState = {
  selectedTab: number | null;
}

const initialState: LocationState = {
  selectedTab: null
}

type LocationAction = {
  type: string;
  payload: LocationState;
}

const locationReducer = (state: LocationState = initialState, action: LocationAction): LocationState => {
  switch (action.type) {
    case (actionTypes.GET_SELECTED_TAB):
      return { ...state, selectedTab: action.payload.selectedTab };
    default:
      return state;
  };
};

export default locationReducer;