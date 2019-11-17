import React, { Component } from 'react';


//interface AddEmployeeActivityDataState {
//    firstName: string;
//    lastName: string;
//    emailAddress: string;
//    activityName: string;
//    comments: string;    
//}

export class AddEmployeeActivity extends Component {
    constructor(props) {
        super(props);
      //  this.state = { firstName: "", lastName: "", emailAddress: "", activityName: "", comments: "", loading:true };
        this.handleSubmit = this.handleSubmit.bind(this);
    }


    render() {
        console.log('rendering');


        return <div>
          
            <h3>Add Employee Activity</h3>
            <hr />
            <form onSubmit={this.handleSubmit} >

                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="firstname">First Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="firstname" required ref={(input) => this.firstName = input} />
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
        console.log(this.firstName.value);
        event.preventDefault();
        const data = new FormData();
       
        data.append('firstName', this.firstName.value);
        console.log(data);


        //// POST request for Add employee activity.          
        fetch('api/EmployeeActivity/AddEmployeeActivityByForm', {
            method: 'POST',
            body: data,
        }).then((response) => response.json())
            .then((responseJson) => {
                this.props.history.push("/fetch-employee-activity");
            })
        
    }


   
}