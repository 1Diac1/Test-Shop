import React, { Component } from 'react';

import styles from './HeaderMenu.module.scss';

class HeaderMenu extends Component {
  render() {
    return (
      <div className={styles.menu__wrapper}>
        <div className={styles.container}>
          <ul>
            <li>ружья</li>
            <li>костюмы</li>
            <li>сухпайки</li>
            <li>рыбалка</li>
            <li>охота</li>
            <li>ножи</li>
          </ul>
          <div className={styles.stock}>акции :x:</div>
        </div>
      </div>
    );
  }
}

export default HeaderMenu;
