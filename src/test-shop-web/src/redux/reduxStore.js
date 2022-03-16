import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunkMiddleware from 'redux-thunk';

import authReducer from './authReducer';
import ThemeReducer from './themeReducer';

let reducers = combineReducers({ authReducer, ThemeReducer });

// для всех других браузеров
// const store = createStore(reducers,applyMiddleware(thunkMiddleware));

// для хрома dev tool
const store = createStore(
  reducers,
  compose(applyMiddleware(thunkMiddleware), window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__()),
);

window.store = store;
console.log(window.store);
export default store;
