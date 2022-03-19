import React from 'react';

import styles from './HeaderSearch.module.scss';
import logo from '../../../assets/images/logo-shop.png';

let HeaderSearch = (props) => {
  return (
    <div className={styles.header__wrapper}>
      <div className={styles.container}>
        <div className={styles.logo}>
          <img src={logo} alt="лого"></img>
        </div>
        <ul>
          <li>Главная</li>
          <li>О нас</li>
          <li>Контакты</li>
        </ul>
        <form className={styles.search__form}>
          <input type="text" placeholder=" Поиск" name="search" />
          <button value="search" type="submit">
            <i class="ti-search"></i>
          </button>
        </form>
        <ul>
          <li>8(800)555-35-35</li>
          <li>дастафка</li>
          <li>()</li>
          <li>\/</li>
          <li>:0</li>
        </ul>
      </div>
    </div>
  );
};

export default HeaderSearch;
