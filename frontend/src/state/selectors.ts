import { CreationState } from './reducers/creationReducer';
import { MonstersState } from './reducers/monstersReducer';
import { CombatState } from './reducers/combatReducer';
import { RootState } from './reducers/reducers';

export const creationState = (state: RootState): CreationState => state.creation;
export const monstersState = (state: RootState): MonstersState => state.monsters;
export const combatState = (state: RootState): CombatState => state.combatants;