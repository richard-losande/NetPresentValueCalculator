import React,{Component} from "react";
import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import { withStyles } from '@material-ui/core/styles';
import axios from 'axios';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import Select from '@material-ui/core/Select';

const styles = theme => ({
    container: {
        display: 'flex',
        flexWrap: 'wrap',
        backgroundColor: 'white'
    },
    textField: {
        marginBottom : theme.spacing(2)
        
      },
      dense: {
        marginTop: 16,  
      },
      menu: {
        width: 200,
      },
      input: {
        display: 'none',
      },
      marginRight :{
          marginRight : 20,
      },
      selectEmpty: {
        marginTop: theme.spacing(2),
      },
})


    class CashFlow extends Component {
        constructor(props) {
            super(props);
            this.state = { 
                cashflows: [] ,
                initialinvestment : 0,
                discountrate: 0,
                upperbound:0,
                lowerbound:0,
                incrementalrate : 0,
                discountratetype : "Fixed", 
            };


        }

        handleSumit = event =>{

            event.preventDefault();
            const netrepresetvaluedata = {
                InitialInvestment : this.state.initialinvestment,
                DiscountRate : this.state.discountrate,
                UpperBound : this.state.upperbound,
                LowerBound : this.state.lowerbound,
                IncrementalRate : this.state.incrementalrate,
                discountratetype : this.state.discountratetype,
                cashflows : this.state.cashflows
            }
            console.log(netrepresetvaluedata);
            axios.post(`/api/NetPresentValue/Compute`, netrepresetvaluedata)
      .then(res => {
        console.log(res);
        console.log(res.data);
      })

    }
        appendInput() {
            var newInput = { id:this.state.cashflows.length == 0 ? 1: this.state.cashflows.length + 1, cashflowamount: 0 }
            this.setState({
                ...this.state,
               cashflows: [...this.state.cashflows, newInput]
            })
        }
        handleChange = (event,key) => {
            const arr = this.state.cashflows;
            const cashflows = arr.map((input, index) => {
                if (key === index)
                    input.cashflowamount = event.target.value;             
                return input;
            });
            this.setState({ cashflows });
        }

        handleChangeInitialInvestment = (event) => {
            this.setState({ initialinvestment: event.target.value });
          }
          handleChangeDiscountRate = (event) => {
            this.setState({ discountrate: event.target.value });
          }

          handleRemoveCashFlow = (index) => {
            console.log(index);
            const newCashFlows = this.state.cashflows;           
            newCashFlows.splice(index, 1);    
          
            newCashFlows.map((cashflow, index) => cashflow.id = index+1);       
            this.setState({
              cashflows: newCashFlows
            });
          }
          handleChangeOnDropDownAge = event => {
            console.log(event.target.value)
            this.setState({discountratetype : event.target.value})
          };
          handleChangeUpperBound =(event)=>
          {
            this.setState({ upperbound: event.target.value });
          }
          handleChangeLowerBound =(event)=>
          {
            this.setState({ lowerbound: event.target.value });
          }
          handleChangeIncrementalRate =(event)=>
          {
            this.setState({ incrementalrate: event.target.value });
          }
          

        render() {
            return(
                <React.Fragment>
                <CssBaseline />
                <Container maxWidth="sm">
                <React.Fragment>  
                <InputLabel >Discount rate type</InputLabel>
        <Select
          value={this.state.discountratetype}
          onChange={this.handleChangeOnDropDownAge.bind(this)}
        >
          <MenuItem value={"Fixed"}>Fixed</MenuItem>
          <MenuItem value={"Incremental"}>Incremental</MenuItem>
        </Select>
        </React.Fragment>
        &nbsp;
        &nbsp;
        &nbsp;
        
              <React.Fragment>              
        <TextField 
                label="Upper Bound"
                id="outlined-basic" 
                variant="outlined"
                value={this.state.upperbound}
                 onChange={this.handleChangeUpperBound.bind(this)} 
                 fullWidth/>  
                  &nbsp;
                &nbsp;
                    <TextField 
                label="Lower Bound"
                id="outlined-basic" 
                variant="outlined" 
                value={this.state.lowerbound}
                 onChange={this.handleChangeLowerBound.bind(this)} 
                 fullWidth/>  
                  &nbsp;
                &nbsp;
                                 <TextField 
                label="Incremental Rate"
                id="outlined-basic" 
                variant="outlined"
                value={this.state.incrementalrate}
                 onChange={this.handleChangeIncrementalRate.bind(this)} 
                 fullWidth/>  
                  &nbsp;
                &nbsp;
                </React.Fragment>
                  <form className={this.props.classes.container} noValidate autoComplete="off" onSubmit= {this.handleSumit} >

                  &nbsp;
                <TextField 
                label="Initial Investment"
                id="outlined-basic" 
                variant="outlined"
                value={this.state.initialinvestment}
                 onChange={this.handleChangeInitialInvestment.bind(this)} 
                 fullWidth/>  
                  &nbsp;             
                <TextField 
                label="Discount Rate"
                id="outlined-basic" 
                variant="outlined"
                value={this.state.discountrate}
                 onChange={this.handleChangeDiscountRate.bind(this)}
                  fullWidth/>
                 {this.state.cashflows.map((input,key) =>
                 <React.Fragment key ={key}>
                   &nbsp;
                    <TextField
                    label="Cash Flow"
                    id={input.value}
                    key={key}
                    value={input.cashflowamount}
                    className={this.props.classes.textField}
                    onChange={event => this.handleChange(event, key)}
                    variant="outlined"
                    fullWidth
                   />
                   <Button variant="contained" color="secondary" align="right" onClick={this.handleRemoveCashFlow.bind(key)} >
                   Delete CashFlow
                 </Button></React.Fragment>)}   
         
                </form>
                <React.Fragment>  
                <Button className ={this.props.classes.marginRight}  onClick={ () => this.appendInput() } variant="contained" color="primary" align="right" >
                  Add CashFlow
                </Button>          
                <Button variant="contained" color="secondary" align="right" type="submit">
                  Calculate
                </Button>  
                </React.Fragment>
                </Container>
              </React.Fragment>
            );
        }

    }
    export default withStyles(styles)(CashFlow);
