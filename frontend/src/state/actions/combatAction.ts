import * as actionTypes from './actionTypes';

export const getCombatantsAction = props => ({
  type: actionTypes.GET_COMBATANTS,
  payload: props
})