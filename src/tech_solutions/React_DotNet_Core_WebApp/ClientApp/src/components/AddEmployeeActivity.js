import React, { Component } from 'react';
import styles from '../custom.css';


export class AddEmployeeActivity extends Component {
    constructor(props) {
        super(props);
        this.state = {            
            errors: {                
                email: ''
            }
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(event) {
        event.preventDefault();
        const { name, value } = event.target;
        let errors = this.state.errors;
        const validEmailRegex = RegExp(/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i);
        
        switch (name) {

            case 'emailAddress':
                errors.email =
                    validEmailRegex.test(value)
                        ? ''
                        : 'Email is not valid!';
                
                this.setState({ errors, [name]: value });
                break;
          
        }
    };

    validateForm(errors){
        let valid = true;
        Object.values(errors).forEach(            
            (val) => val.length > 0 && (valid = false)
        );
        return valid;
    };

    render() {
        const { errors } = this.state;
        console.log(errors.email);
        return <div>
          
            <h3>Add Employee Activity</h3>
            <hr />
            <form onSubmit={this.handleSubmit} >

                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="firstname">First Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="firstname" required ref={(input) => this.firstName = input} />
                    </div>
                </div >
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="lastName">Last Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="lastName" required ref={(input) => this.lastName = input} />
                    </div>
                </div>
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="emailAddress">Email Address</label>
                    <div className="col-md-4">
                        <input className="form-control" onChange={this.handleChange} type="text" name="emailAddress" required ref={(input) => this.emailAddress = input} />
                        {errors.email.length > 0 &&
                            <span className="error">{errors.email}</span>}
                    </div>
                </div >
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="activityName">Activity Name</label>
                    <div className="col-md-4">
                      
                        <select id="activityName" ref={(input) => this.activityName = input}>
                            <option value="Developing in .Net Core ReactJs">Developing in .Net Core ReactJs</option>
                            <option value="Developing in .Net Core Angular">Developing in .Net Core Angular</option>
                            <option value="Developing in .Net Core ReactJs And Redux">Developing in .Net Core ReactJs And Redux</option>
                        </select>


                    </div>
                </div >
                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="comments">Comments</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="comments" required ref={(input) => this.comments = input} />
                    </div>
                </div >



                <div className="form-group">
                    <button type="submit" value="post" className="btn btn-default">Add</button>
                </div >
            </form >
        </div>;
    }

    // This will handle the submit form event.  
    handleSubmit(event) {
        console.log(this.activityName.value);
        event.preventDefault();

        if (this.validateForm(this.state.errors))
        {
            //const data = new FormData(event.target);
            const data = new FormData();
            data.append("activityName", this.activityName.value);
            data.append("firstName", this.firstName.value)
            data.append("lastName", this.lastName.value)
            data.append("emailAddress", this.emailAddress.value)
            data.append("comments", this.comments.value)


            //// POST request for Add employee activity.          
            fetch('api/EmployeeActivity/AddEmployeeActivityByForm', {
                method: 'POST',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetch-employee-activity");
                })

        }
        else
        {
            console.info('invalid form');
        }

       
    }


   
}