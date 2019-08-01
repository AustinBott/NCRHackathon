<template>
    <form novalidate class="md-layout">
        <md-card-content class="md-layout-item md-size-50 md-small-size-100">
            <md-card-content>
                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <div v-if="newCheck">
                                <md-field>
                                <div class="item title">Check:</div>
                                <md-input class="item" v-model="check.metadata.name"/>
                            </md-field>
                            <md-field>
                                <div class="item title">Namespace: </div>
                                <md-input class="item" v-model="check.metadata.namespace"/>
                            </md-field>
                        </div>
                        <div v-else>
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
                            <md-input class="item" v-model="check.high_flap_threshold" />
                        </md-field>
                    </div>
                </div>
                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Low Flap Threshold: </div>
                            <md-input class="item" v-model="check.low_flap_threshold" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Intervals: </div>
                            <md-input class="item" v-model="check.interval" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Publish: </div>
                            <md-input class="item" v-model="check.publish" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Runtime Assets: </div>
                            <div v-for="(rta, index) in check.runtime_assets" v-bind:key="index">
                                <md-input class="item" v-model="check.runtime_assets[index]" />
                            </div>
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Subscriptions: </div>
                            <div v-for="(subscription, index) in check.subscriptions" v-bind:key="index">
                                <md-input class="item" v-model="check.subscriptions[index]" />
                            </div>
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
                            <md-input class="item" v-model="check.stdin" />
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
                            <md-input class="item" v-model="check.ttl" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Timeout: </div>
                            <md-input class="item" v-model="check.timeout" />
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Round Robin: </div>
                            <md-input class="item" v-model="check.round_robin" />
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
                            <div v-for="(omh, index) in check.output_metric_handlers" v-bind:key="index">
                                <md-input class="item" v-model="check.output_metric_handlers[index]" />
                            </div>
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
                            <div v-for="(hook, index) in check.hooks" v-bind:key="index">
                                <md-input class="item" v-model="check.hooks[index]" />
                            </div>
                        </md-field>
                    </div>
                </div>

                <div class="md-layout md-gutter">
                    <div class="md-layout-item md-small-size-100">
                        <md-field>
                            <div class="item title">Handlers: </div>
                            <div v-for="(handler, index) in check.handlers" v-bind:key="index">
                                <md-input class="item" v-model="check.handlers[index]" />
                            </div>
                        </md-field>
                    </div>
                </div>

            </md-card-content>

        </md-card-content>
        <div class = "blank">
        </div>
    </form> 
</template>


<script>
import hook from './hook'
import handler from './handler'
export default {
    props:{
        isSelected: Boolean,
        selectedAgentId: ['selectedAgentId'],
        check: Object,
        newCheck: Boolean
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
    }

    .blank{
        padding:30px;   
    }
</style>