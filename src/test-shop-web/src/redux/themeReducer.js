const ThemeReducer = (state = {}, action) => {
  switch (action.type) {
    case 'SET_MODE':
      return {
        ...state,
        mode: action.payload,
      };
    case 'SET_COLOR':
      return {
        ...state,
        color: action.payload,
      };
    default:
      return state;
  }
};

export default ThemeReducer;

export const setMode = (mode) => {
  return {
    type: 'SET_MODE',
    payload: mode,
  };
};

export const setColor = (color) => {
  return {
    type: 'SET_COLOR',
    payload: color,
  };
};

export const getTheme = () => {
  return {
    type: 'GET_THEME',
  };
};
