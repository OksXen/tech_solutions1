import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Acme Widget Company</h1>
        <p>Welcome to a single-page application</p>
            <ul>
                <li><a href='/add-employee-activity'>Click here for Activity sing up form</a></li>   
                <li><a href='/fetch-employee-activity'>Click here for Interested Person Listing</a></li>
                <li><a href='/fetch-employee-activity-by-dapper'>Click here for Interested Person Listing By Dapper</a></li>
                      
        </ul>        
      </div>
    );
  }
}
