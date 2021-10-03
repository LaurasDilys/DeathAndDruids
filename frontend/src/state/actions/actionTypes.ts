import { combineReducers } from 'redux';
import type { StateType } from 'typesafe-actions';
import { applyMiddleware, createStore } from 'redux';
// import { composeWithDevTools } from 'redux-devtools-extension';
// import thunk from 'redux-thunk';



// actionTypes (here)
export const NEW_CHARACTER = "NEW_CHARACTER";



// action
type CreationAction = {
  type: string;
}

export const NewCharacter = (): CreationAction => ({
  type: NEW_CHARACTER
})



// reducer
export type Character = {
  id: number,
  name: string,
  initiative: number,
  hp: number,
  maxHp: number
}

export type CreationState = {
  characters: Character[]
}

const initialState: CreationState = {
  characters: []
}

export const creationReducer = (state: CreationState = initialState, action: CreationAction): CreationState => {
  switch (action.type) {
    case NEW_CHARACTER: {
      //
      const newCharacter = {
        id: 0,
        name: "Zero",
        initiative: 0,
        hp: 0,
        maxHp: 0
      }
      //
      return { characters: [...state.characters, newCharacter] };
    };
    default:
      return state;
  };
};

// reducers.ts
export const reducers = combineReducers({ creationReducer });
export type RootState = StateType<typeof reducers>;

// export default reducers;



// selector
export const getCharacters = (state: RootState): CreationState => state.creationReducer;



// store
export default function configureStore() {

  // const middlewareEnhancer = applyMiddleware(thunk);

  // const composedEnhancers = composeWithDevTools(middlewareEnhancer);

  const store = createStore(reducers);

  return store;
}
