<template>
    <form novalidate class="md-layout">
        <md-card-content class="md-layout-item md-size-50 md-small-size-100">
            <md-card-header>
                <div class="md-title">Edit Check</div>
            </md-card-header>

            <md-card-content>
                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Check:</div>
                            <div class="item">{{check.metadata.name}} </div>
                        </md-field>
                        <md-field>
                            <div class="item title">Namespace: </div>
                            <div class="item">{{check.metadata.namespace}} </div>
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Command: </div>
                            <md-input class="item" v-model="check.command" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">High Flap Threshold: </div>
                            <md-input type="number" class="item" v-model.number="check.high_flap_threshold" />
                        </md-field>
                    </div>
                </div>
                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Low Flap Threshold: </div>
                            <md-input type="number" class="item" v-model.number="check.low_flap_threshold" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Intervals: </div>
                            <md-input type="number" class="item" v-model.number="check.interval" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Publish: </div>
                            <md-checkbox v-model="check.publish"></md-checkbox>
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Runtime Assets: </div>
                            <md-input class="item" v-model="check.runtime_assets[0]" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Subscriptions: </div>
                            <md-input class="item" v-model="check.subscriptions[0]" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Proxy Entity Name: </div>
                            <md-input class="item" v-model="check.proxy_entity_name" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Check Hooks: </div>
                            <md-input class="item" v-model="check.check_hooks" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Standard In: </div>
                            <md-checkbox v-model="check.stdin"></md-checkbox>
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Subdue: </div>
                            <md-input class="item" v-model="check.subdue" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">TTL: </div>
                            <md-input type="number" class="item" v-model.number="check.ttl" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Timeout: </div>
                            <md-input type="number" class="item" v-model.number="check.timeout" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Round Robin: </div>
                            <md-checkbox v-model="check.round_robin"></md-checkbox>
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Output Metric Format: </div>
                            <md-input class="item" v-model="check.output_metric_format" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Output Metric Handlers: </div>
                            <md-input class="item" v-model="check.output_metric_handlers[0]" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Environment Variables: </div>
                            <md-input class="item" v-model="check.env_vars" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Hooks: </div>
                            <div class="item" v-for="(hook, index) in check.hooks" v-bind:key="index">
                                <hook v-bind:hook="hook" />
                                <md-input />
                            </div>
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Handlers: </div>
                            <div class = "item" v-for="(handler,index) in check.handlers" v-bind:key="index">
                                <handler v-bind:handler="handler"/>
                            </div>
                            <!--<md-input />
                            <md-input />-->
                        </md-field>
                    </div>
                </div>

            </md-card-content>

        </md-card-content>
    </form> 


    <!--<div id="check" class = "card" :class="{selected:isSelected}">
        <div class = "table">
            <div class = "row">
               <div class="item title">Check:</div>
                <input class = "item">
            </div>
            <div class = "row">
                <div class="item title">Metadata:</div>
                <input class = "item" v-model="check.metadata.namespace">
                <input class = "item" v-model="check.metadata.name">
            </div>
            <div class="row">
                <div class="item title">Subscrptions:</div>
                <div class="item" v-for="(subscription, index) in check.subscriptions" v-bind:key="index">
                    <input v-model="subscription.name">
                </div>
            </div>
            <div class = "row">
               <div class = "item"> Hooks: </div>
            </div>
           <div class="row">
                <div class = "item"
                v-for="(hook, index) in check.hooks" v-bind:key="index">
                    <hook
                    v-bind:hook="hook"/>
                </div>
            </div>
            <div class = "row">
               <div class = "item"> Handlers: </div>
            </div>
            <div class="row">
                <div class = "item"
                v-for="(handler,index) in check.handlers" v-bind:key="index">
                    <handler
                    v-bind:handler="handler"/>
                </div>
            </div>
        </div>
    </div>-->
</template>


<script>
import hook from './hook'
import handler from './handler'
export default {
    props:{
        isSelected: Boolean,
        selectedAgentId: ['selectedAgentId'],
        check: Object
    },
    components:{
        hook,
        handler
    },
}
</script>

<style scoped>
    .card{
        width: 100%;
        display: flex;
        border: 1px blue solid;
        flex-direction: column;
    }
    .card.selected{
        border: 4px red solid;
        background: yellow;
    }
    .table{
        width: 100%;
        border: 1px green solid;
        display: flex;
        justify-content: space-evenly;
        flex-direction: column;
        overflow: hidden;
    }
    .row{
        border: 1px red solid;
        display: flex;
        flex-direction: row;
        margin: 2px;
        padding: 0px 5px;
        flex-wrap: wrap;
        justify-content: left;
    }
    .item{
        margin: 5px;
        padding: 5px;
        font: 2px;
        overflow: hidden;
    }
</style>