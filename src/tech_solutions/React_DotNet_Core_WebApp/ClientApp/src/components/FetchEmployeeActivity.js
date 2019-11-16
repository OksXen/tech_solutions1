import React, { Component } from 'react';

export class FetchEmployeeActivity extends Component {
    static displayName = FetchEmployeeActivity.name;

    constructor(props) {
        super(props);
        this.state = { employeeActivity: [], loading: true };
    }

    componentDidMount() {
        this.populateEmployeeActivity();
    }

    static renderEmployeeActivityTable(employeeActivities) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Activity Id</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email Address</th>
                        <th>Activity Name</th>
                        <th>Comments</th>
                    </tr>
                </thead>
                <tbody>
                    {employeeActivities.map(employeeActivity =>
                        <tr key={employeeActivity.activityId}>
                            <td>{employeeActivity.activityId}</td>
                            <td>{employeeActivity.firstName}</td>
                            <td>{employeeActivity.lastName}</td>
                            <td>{employeeActivity.emailAddress}</td>
                            <td>{employeeActivity.activityName}</td>
                            <td>{employeeActivity.comments}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchEmployeeActivity.renderEmployeeActivityTable(this.state.employeeActivity);

        return (
            <div>
                <h1 id="tabelLabel" >Employee Activities</h1>                
                {contents}
            </div>
        );
    }

    async populateEmployeeActivity() {
        const response = await fetch('api/EmployeeActivity');
        const data = await response.json();
        this.setState({ employeeActivity: data, loading: false });
    }
}
