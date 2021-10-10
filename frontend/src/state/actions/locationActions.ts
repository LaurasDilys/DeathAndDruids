import * as actionTypes from './actionTypes';

export const getSelectedTabAction = props => ({
  type: actionTypes.GET_SELECTED_TAB,
  payload: props
})