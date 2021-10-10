import { combineReducers } from 'redux';
import type { StateType } from 'typesafe-actions';
import creation from './creationReducer';
import monsters from './monstersReducer';
import combatants from './combatReducer';
import location from './locationReducer';

const reducers = combineReducers({ creation, monsters, combatants, location });
export type RootState = StateType<typeof reducers>;

export default reducers;