import React, { Component } from 'react';

class Login extends Component {
  render() {
    return (
      <div className="main">
        <input type="checkbox" id="chk" aria-hidden="true" />

        <div className="signup">
          <form>
            <label for="chk" aria-hidden="true">
              Регистрация
            </label>
            <input type="text" name="txt" placeholder="Имя" required="" />
            <input type="email" name="email" placeholder="Email" required="" />
            <input type="password" name="pswd" placeholder="Пароль" required="" />
            <button>Зарегистрироваться</button>
          </form>
        </div>

        <div className="login">
          <form>
            <label for="chk" aria-hidden="true">
              Войти
            </label>
            <input type="email" name="email" placeholder="Email" required="" />
            <input type="password" name="pswd" placeholder="Password" required="" />
            <button>Войти</button>
          </form>
        </div>
      </div>
    );
  }
}

export default Login;
