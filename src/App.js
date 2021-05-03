import {TextField,Button,Grid,Paper} from '@material-ui/core';
import React from 'react';
import {getRequest} from './_helpers/api';



class App extends React.Component{
  constructor(){
    super()
    this.state={
      searchValue:'online title search',
      searchResult:'1,2,2,2,4'
    }
  }

  handleGoogleSubmit = (event) => {
    event.preventDefault()
    console.log('Getting Google search result');
    getRequest("api/Search/GetGoogle?searchValue="+this.state.searchValue)
    .then((res)=> {
      console.log("getting response");
      this.setState({
        searchResult:res.data
      })
    })
    .catch((error) =>{
      console.log("getting get response from api");
      this.setState({
        searchResult:"No result return"
      })
    })

  }

  handleBingSubmit = (event) => {
    event.preventDefault()
    console.log('Getting Bing search result');
    getRequest("api/Search/GetBing?searchValue="+this.state.searchValue)
    .then((res)=> {
      console.log("getting response");
      this.setState({
        searchResult:res.data
      })
    })
    .catch((error) =>{
      console.log("getting get response from api");
      this.setState({
        searchResult:"No result return"
      })
    })

  }

  handleChange = (event) => {
    this.setState({searchValue: event.target.value})

  }
  render(){
    return (
      <div className="App">
        <form autoComplete="off">
        <div>
          <h2>Enter the search keyword</h2>
        </div>
        <br />
        <fieldset>
          <TextField required id="searchkey" name="searchkeyword" label="Search Keyword"
          value={this.state.searchValue} 
          onChange={this.handleChange}
          error={this.state.searchValue===""}
          helperText={this.state.searchValue === "" ? 'Please enter search value!' : ' '}
          style={{width:400}}>
  
          </TextField>
        </fieldset>
        <br />
        <div>
        <Grid container spacing={3}>
          <Grid item xs={3}>
            <Button variant="contained" color="primary" onClick={this.handleGoogleSubmit}>
                      Google Search
            </Button>
          </Grid>
           

          <Grid item xs={9}>
            <Button variant="contained" color="primary" onClick={this.handleBingSubmit}>
                      Bing Search
            </Button>
          </Grid>
          
        </Grid>
        </div>
        </form>

        <br /><br />
        <div>
          <Paper>{this.state.searchResult}</Paper>
        </div>
                
     
  
      </div>
    );

  }


  
}

export default App;
